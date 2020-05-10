#include <avr/io.h>
#include <util/delay.h>

int main(void)
{
    //DDRD -  Port D Data Direction Register
	//for each port pin, 1 = write, 0 = read
	DDRD = 0x01; //Set PORTD, pin 0 as output
    while (1) 
    {
		PORTD = 0x01; //Make pin 0 on port D 5V
		_delay_ms(300); //Wait for 1 second
		PORTD = 0x00; //Make all pins on port D 0V
		_delay_ms(300); //Wait again for 1 second
    }
}

