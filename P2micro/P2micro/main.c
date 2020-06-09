#define F_CPU 1000000UL
#include <avr/io.h>
#include <util/delay.h>
#include <stdint.h>
#define BAUD 4800
#define MYUBRR F_CPU/16/BAUD-1

void ADC_Init()
{
	//Selecteaza Vref ca AVCC, rezultatul ajustat la dreapta
	//si canalul analog de intrare ca ADC0
	ADMUX = 0x00;
	
	//Activeaza ADC, selecteaza intreruperile si 
	//defineste frecventa de lucru a ADC la XTAL/2
	ADCSRA = 0x80;
}

void Conversie(unsigned char *lower, unsigned char *higher)
{
	ADCSRA = (ADCSRA | (1 << 6)); //Porneste o conversie setand ADSC
	while( (ADCSRA | (0xBF)) != (0xBF) )  ; //Asteapta sa se termine conversia (ADSC resetat de hw)
	*lower = ADCL; //Citeste LSBits
	*higher = ADCH; //Citeste MSBits
	
}


void USART_Transmit( int data )
{
	/* Wait for empty transmit buffer */
	while ( !( UCSR0A & (1<<UDRE0)) )
	;
	/* Put data into buffer, sends the data */
	UDR0 = data;
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

unsigned char USART_Receive( void )
{
	/* Wait for data to be received */
	while ( !(UCSR0A & (1<<RXC0)) )
	;
	/* Get and return received data from buffer */
	return UDR0;
}

int main(void)
{
	//Initializare USART
	USART_Init ( MYUBRR );
	
	//Initializare ADC
	//ADC_Init();	

	//uint8_t low, high;
	//int value;
	DDRD = 0xFF;
	
    while (1) 
    {
		PORTD = 0xFF;
		_delay_ms(2000);
		PORTD = 0x00;
		_delay_ms(2000);
    }
}

