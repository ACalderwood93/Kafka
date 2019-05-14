Experimenting with setting up a simple soloution for using the Confluent Kafka client.

Trying to create a class to abstract the functionality of the consumer and only allow access to some event 
that handles the deserialization of a json object and returns the object in the action. 

Should make using the kafka client to consume as simple as a few lines of code.
Also makes it more extentible, I.E can create a class to implement serialisation from binary/XML or whatever type of data is the chosen format.
