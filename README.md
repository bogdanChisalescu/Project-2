# Project-2
A brief project consisting in the implementation of a plant watering system. <br/> <br/>
**A more detailed and in depth description can be found in Documentation -> Project_Documentation.pdf, written in romanian.**

**Task:** implement a plant watering system using the Atmel ATmega 164A microcontroller. <br/> <br/>

**Solution:** Me and my colleague [sobitor98](https://github.com/sobitor98), used two sensors and one actuator: a soil moisture sensor, a water level sensor and a mini pump. To enhance the user experience we also developed a C# Windows Desktop app using Windows Forms. The app lets the user set up a threshold for soil moisture and check the parameters in real time (the soil moisture and the water level in the tank). <br/> <br/>

**Important aspects that we coverd and encountered during the project:** <br/> 
  - Understanding the AVR microcontroller architecture
  - Understanding the underlying connctions between digital circuits and the control and programming of a microprocessor
  - Performing calibration of sensors
  - Coupling an external crystal oscillator
  - Establishing data communication across a serial interface (USB and USART)
  - Programming a microcontroller
  - Making use of results given by an Analog to Digital Converter
  <br/> <br/>
  **Problems encountered along the way:** <br/>
  - The mini pump was not functional out of the box, **but** we managed to fix it, we have seen a reduction in flow rate and an increase in the current consumption
  - At a clock speed of 1 MHz the ATmega 164A was not able to produce a baud rate higher than 4800, fixed by coupling an external oscillator
  - The result of the ADC conversion is very unconcludent, we did not find a fix for this
  <br/> <br/>
  **The system implemented on the microcontroller is a 3 state finite state automata:**
  1. First state: the MCU performs it's normal job of checking the soil mositure and watering the plant if needed
  2. Second state: the MCU establishes a connection with the PC and continuously sends real time parameters
  3. Third state: the MCU receives a configuration parameter from the PC and immediately enters the second state continuing to work with the received parameter in the third stage <br/> <br/>
   Unfortunately the data received on the PC is relatively irrelevant, this might be because the bytes transmitted are received out of order, for a more consistent and relevant transmission we could have used forward error correction.  
    


