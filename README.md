# TMCC-LegacySniffer
 Listen to commands sent through Lionel SER2 or BASE

How to use:

1. Open sniffer
2. Ensure that your DB9 cable is connected to a LIONEL SER2, or a BASE. Note that TMCC2 (legacy) commands can only be read from a SER2. 
3. Type in number of com port you want to listen to. Use device manager to figure out the one you need.
4. If you made a mistake, you have unlimited chances. 
5. Press any button on a CAB1, CAB1L, CAB2, or iCAB to listen to the commands. Commands are sent via the serial port immediately. 

The Hex and binary of the command is sent through. Sometimes commands are not sent cleanly, so you'll need to try a couple times.

Credits:

Microsoft - Base code

https://stackoverflow.com/questions/3581674/converting-a-byte-to-a-binary-string-in-c-sharp - For learning how to print binary properly
