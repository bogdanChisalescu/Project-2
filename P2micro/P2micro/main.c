/*
 * P2micro.c
 *
 * Created: 5/3/2020 12:01:14
 * Author : Bogdan
 */ 

#include <avr/io.h>
#include <util/delay.h>

int main(void)
{
    /* Replace with your application code */
	DDRC = 0xFF; //Set PORTC as output
    while (1) 
    {
		PORTC = 0xFF; //Make all pins on port C 5V
		_delay_ms(1000); //Wait for 1 second
		PORTC = 0x00; //Make all pins on port C 0V
		_delay_ms(1000); //Wait again for 1 second
    }
}

