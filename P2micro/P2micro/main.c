#include <avr/io.h>
#include <util/delay.h>

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

void USART_Transmit( unsigned int data )
{
	/* Wait for empty transmit buffer */
	while ( !( UCSR0A & (1<<UDRE0)) )
	;
	/* Put data into buffer, sends the data */
	UDR0 = data;
}


int main(void)
{
	
	USART_Init(9600);
    //DDRD -  Port D Data Direction Register
	//for each port pin, 1 = write, 0 = read
	//DDRD = 0x01; //Set PORTD, pin 0 as output
	unsigned int value = 0;
    while (1) 
    {
		USART_Transmit(value);
		//PORTD = 0x01; //Make pin 0 on port D 5V
		//_delay_ms(300); //Wait for 1 second
		//PORTD = 0x00; //Make all pins on port D 0V
		_delay_ms(1000); //Wait again for 1 second
		++value;
    }
}

