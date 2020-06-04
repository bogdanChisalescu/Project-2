#include <avr/io.h>
#include <util/delay.h>
#define BAUD 4800
#define MYUBRR F_CPU/16/BAUD-1
void USART_Transmit( unsigned char data )
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
	USART_Init ( MYUBRR );
	
	unsigned char c = 'a';
	
    while (1) 
    {
		USART_Transmit(c);
		USART_Transmit('\n');
		++c;
		_delay_ms(2000);
    }
}

