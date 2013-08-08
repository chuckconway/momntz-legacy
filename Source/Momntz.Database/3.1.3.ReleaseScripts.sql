
--UI Logging Endpoints
IF Not Exists(Select Id From Configuration Where Name = 'UILogging.Endpoint' AND Environment = 'LOCAL')
BEGIN
        Insert Into Configuration(Name, Value, Environment)Values('UILogging.Endpoint', 'https://logs.loggly.com/inputs/eb327efb-a0a5-4f33-b931-275f32739d8c', 'LOCAL')
END

IF Not Exists(Select Id From Configuration Where Name = 'UILogging.Endpoint' AND Environment = 'QA')
BEGIN
        Insert Into Configuration(Name, Value, Environment)Values('UILogging.Endpoint', 'https://logs.loggly.com/inputs/6da95512-9a43-4276-9d16-389cf3176015', 'QA')
END

IF Not Exists(Select Id From Configuration Where Name = 'UILogging.Endpoint' AND Environment = 'PROD')
BEGIN
        Insert Into Configuration(Name, Value, Environment)Values('UILogging.Endpoint', 'https://logs.loggly.com/inputs/2f4741ef-4914-4b7a-aac0-74803fb39b36', 'PROD')
END


--Service Logging
IF Not Exists(Select Id From Configuration Where Name = 'ServiceLogging.Endpoint' AND Environment = 'LOCAL')
BEGIN
        Insert Into Configuration(Name, Value, Environment)Values('ServiceLogging.Endpoint', 'https://logs.loggly.com/inputs/d7aa4078-bbe6-400e-958e-4fb08497f2de', 'LOCAL')
END

IF Not Exists(Select Id From Configuration Where Name = 'ServiceLogging.Endpoint' AND Environment = 'QA')
BEGIN
        Insert Into Configuration(Name, Value, Environment)Values('ServiceLogging.Endpoint', 'https://logs.loggly.com/inputs/c63cb2e2-1153-463c-b5c6-7ce3c1d4a9c4', 'QA')
END

IF Not Exists(Select Id From Configuration Where Name = 'ServiceLogging.Endpoint' AND Environment = 'PROD')
BEGIN
        Insert Into Configuration(Name, Value, Environment)Values('ServiceLogging.Endpoint', 'https://logs.loggly.com/inputs/0040b99d-474d-415d-a747-ce071afc7839', 'PROD')
END