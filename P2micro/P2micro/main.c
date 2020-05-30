#include <avr/io.h>
#include <util/delay.h>
#define fOSC 1000000

void USART_Transmit(char data )
{
	/* Wait for empty transmit buffer */
	while ( !( UCSR0A & (1<<UDRE0)) )
	;
	/* Put data into buffer, sends the data */
	UDR0 = data;
}


int main(void)
{

	//UCSR0B - resgistrul de stare si control USART B
	//Activeaza transmisia setand bitul 3  
	UCSR0B = 0x08;
	
	//UCSR0C - resgistrul de stare si control USART C
	//Valoarea actuala seteaza modul asincron, verificarea paritatii dezactivata,
	//1 bit de stop, impreuna cu bitul 2 din UCSR0B 8 biti de date si ceasul pentru
	//comunicatia sincrona dezactivat (fiind activa cea asincrona)
	UCSR0C = 0x06;
	
	//Seteaza baud rate pentru o frecventa de 1MHz a ceasului
	unsigned int BAUD = 9600;
	BAUD = BAUD << 8;
	UBRR0 = fOSC / BAUD - 1;
 
	char character = 'a';
    while (1) 
    {
		USART_Transmit(character);
		USART_Transmit('\n');
		_delay_ms(2000); //Wait for 2 seconds
		++character;
    }
}

