#define F_CPU 20000000UL
#include <avr/io.h>
#include <util/delay.h>
#include <stdint.h>
#define MINUT 60000
#define VREF 5.1
#define DEBIT 0.43
#define BAUD 9600
#define MYUBRR F_CPU/16/BAUD-1

union {
	float f;
	char bytes[4];
} joinedFloat;

union {
	int i;
	char bytes[2];
} joinedInt;

float cantitateApa = -1; //L  // configurare numai prin aplicatie
int umiditatePrag = -1; //[%]  // configurare numai prin aplicatie  

void ADC_Init();
void USART_Transmit( unsigned char data );
void USART_Init( unsigned int baud );
unsigned char USART_Receive( void );
void Conversie(unsigned char *low, unsigned char *high);
void stateConnected(unsigned char command);
void stateReading(unsigned char command);
int preiaDateUmiditate();
int preiaDateNivel();

int main(void)
{
	//Initializare USART
	USART_Init ( MYUBRR );
	
	//Initializare ADC
	ADC_Init();

	//DDRD = 0xFF;
	unsigned char command;
	int umiditate; //[%]
	int nivel; // [mm]
	
    while (1) 
    {
		command = UDR0;
		if(command == 'c')
			stateConnected(command);
		umiditate = preiaDateUmiditate();
		if(umiditatePrag != -1)
			if(umiditate < umiditatePrag && cantitateApa != -1){
				nivel = preiaDateNivel();
				if(nivel > 0 && nivel <= 40){
					float t = cantitateApa / DEBIT; //Calcul timpul in care se tine pompa deschisa
					t *= 60; //Conversie in secunde
					const int timp = t * 1000; //Conversie in ms
					DDRD = 0xFF; //Setam portul D ca output
					PORTD = 0xFF; //Setam potentialul Vm la aprox. Vcc = 5V
					_delay_ms(1000); //Tinem pompa activa un anumit timp ------------------------> PROBLEMA
					PORTD = 0x00; //Inchidem pompa
					_delay_ms(MINUT);//Asteptam un minut pentru infiltrarea apei in sol
				}
			}	
    }
}

	//Returneaza umiditatea in procente
int preiaDateUmiditate(){
	
	//Selecteaza canalul ADC0 pentru conversie (XOR cu 0x01)
	ADMUX = ADMUX ^ 0x01;
	
	ADCSRA = (ADCSRA | (1 << ADSC)); //Porneste o conversie setand ADSC
	while((ADCSRA&(1<<ADIF))==0);   //Asteapta sa se termine conversia (ADSC resetat de hw)
	
	//A doua conversie deoarece din cauza schimbarii canalului
	//este posibil ca prima sa nu fie corecta
	ADCSRA = (ADCSRA | (1 << ADSC)); //Porneste o conversie setand ADSC
	while((ADCSRA&(1<<ADIF))==0);   //Asteapta sa se termine conversia (ADSC resetat de hw)
	
	unsigned int convLow = ADCL; //Citim ADCL
	unsigned int convHigh = (unsigned int)(ADCH << 8); //Citim ADCH si facem loc pentru ADCL shitand la stanga 8 pozitii
	unsigned int conv = convLow | convHigh; //Concatenam ADCL cu ADCH
	
	float resConv = (conv * VREF) / 1023.0; //Rezultatul conversiei in V
	int umiditate = -5 * (5*resConv -24); //Umiditatea in procente (0-100)
	
	return (umiditate / 10) * 10; //Discretizarea valorilor pe 10 intervale pentru a minimiza eroarea aprox. caracteristicii
	
}

	//Returneaza nivelul din vas in mm
int preiaDateNivel(){
	
	//Selecteaza canalul ADC1 pentru conversie (SAU cu 0x01)
	ADMUX = ADMUX ^ 0x01;
	
	ADCSRA = (ADCSRA | (1 << ADSC)); //Porneste o conversie setand ADSC
	while((ADCSRA&(1<<ADIF))==0);   //Asteapta sa se termine conversia (ADSC resetat de hw)
	
	//A doua conversie deoarece din cauza schimbarii canalului
	//este posibil ca prima sa nu fie corecta
	ADCSRA = (ADCSRA | (1 << ADSC)); //Porneste o conversie setand ADSC
	while((ADCSRA&(1<<ADIF))==0);   //Asteapta sa se termine conversia (ADSC resetat de hw)
	
	unsigned int convLow = ADCL; //Citim ADCL
	unsigned int convHigh = (unsigned int)(ADCH << 8); //Citim ADCH si facem loc pentru ADCL shitand la stanga 8 pozitii
	unsigned int conv = convLow | convHigh; //Concatenam ADCL cu ADCH
	
	float resConv = (conv * VREF) / 1023.0; //Rezultatul conversiei in V
	int nivel = (100 * resConv - 200) / 3; //Nivelul in mm (0-40)
	
	return nivel;
	
}

void stateConnected(unsigned char command){
	
	int OK = 0;
	
	while(command == 'c'){
		
		if(!OK){
			USART_Transmit('a'); //Transmitere mesaj de confirmare intrare in starea de conectat
			OK = 1;
		}
		int umiditate = preiaDateUmiditate(); //Se preia umiditatea
		int nivel = preiaDateNivel(); //Se preia nivelul apei
		unsigned char *p;
		p = (unsigned char*)&umiditate;
		USART_Transmit(*p++);
		USART_Transmit(*p);
		p = (unsigned char*)&nivel;
		USART_Transmit(*p++);
		USART_Transmit(*p);
		
		_delay_ms(2000);
		

		command = UDR0;
		if(command == 'r'){
			stateReading(command);
			command = UDR0;
			command = 'c';
		}
		else if(command != 'b')
			command = 'c';
			
	}
}

void stateReading(unsigned char command){
	
	int i;
	for(i=0;i<4;i++){
		joinedFloat.bytes[3-i] = USART_Receive();
	}
	
	cantitateApa = joinedFloat.f;
	
	for(i=0;i<2;i++){
		joinedInt.bytes[1-i] = USART_Receive();
	}
	
	umiditatePrag = joinedInt.i;
}


void ADC_Init()
{
	//Activeaza ADC, selecteaza intreruperile si
	//defineste frecventa de lucru a ADC la XTAL/2
	ADCSRA = 0x87;
	
	//Selecteaza Vref ca AVCC, rezultatul ajustat la dreapta
	//si canalul analog de intrare ca ADC0
	ADMUX = 0x40;
}

void USART_Init( unsigned int baud )
{
	/* Set baud rate */
	UBRR0H = (unsigned char)(baud>>8);
	UBRR0L = (unsigned char)baud;
	/* Enable receiver and transmitter */
	UCSR0B = (1<<RXEN0)|(1<<TXEN0);
	/* Set frame format: 8data, 2stop bit */
	UCSR0C = (1<<USBS0)|(3<<UCSZ00);
}

void USART_Transmit( unsigned char data )
{
	/* Wait for empty transmit buffer */
	while ( !( UCSR0A & (1<<UDRE0)) )
	;
	/* Put data into buffer, sends the data */
	UDR0 = data;
}

unsigned char USART_Receive( void )
{
	/* Wait for data to be received */
	while ( !(UCSR0A & (1<<RXC0)) )
	;
	/* Get and return received data from buffer */
	return UDR0;
}


