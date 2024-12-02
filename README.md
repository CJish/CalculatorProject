Question #4: The Calculator class handles the bulk of the calculation work, and the Program class handles
the user interface and error-capturing work. Would it be a good idea to move the user interface
and error-capturing work from the Program class to the Calculator class? Please briefly discuss.

Answer: The idea of moving the user interface and error-capturing work from the Program class to the Calculator class
would be like driving a car with your feet: you CAN do it, but it's not a good idea. This violates SOLID design 
principles in many ways. First, the program as-is already violates the SOLID design principles by combining the 
output layer (analogous to the 'View' layer in an MVC construct) with the logic layer; I'd prefer these to be 
separated. But combining the calculation logic with the program logic with the I/O logic is asking for trouble;
what a programmer thinks is a slight change to the I/O may end up messing with the calculation logic or program 
logic. For a simple program like this calculator, that will likely result in dozens of minutes of troubleshooting.
But as the program doubles in complexity, the violation of the Single Responsibility principle has - in my
experience - an exponential growth in troubleshooting time.

I think this is a strong enough explanation to forego any of the other SOLID principles that would be violated
by the integration of these two classes, but I'm happy to answer any questions.
