#Notification Service

## Description
This service provides the ability to notify users about events related to their cards. Events are accepted in JSON format via the POST method and are stored in the database. A worker/job is also implemented to notify clients by simply outputting notifications to the terminal.

## Usage of Standard Library
To solve this task, only the C# standard library is utilized. The worker/job is created using custom worker/job (without IHostedService, BackgroundService) with the use of background threads.

## Build and Run Instructions
Clone the repository with the solution:
```shell
git clone git@github.com:Defstrong/NotificationTask.git
```
Navigate to the project directory: 
```shell
cd AlifDeveloperTest
```
Build the project: 
```shell
dotnet build
```
Navigate to the data operations directory for migration.
```
cd src/DataAccess
```
Perform the migration:
```
dotnet ef database update
```
Navigate to the project launch directory.
```
cd src/Presentation
```
Start the HTTP server and the worker: 
```
dotnet run
```

## Simplicity of the Solution
The solution is designed for simplicity and ease of understanding. The entire code is written in a simple and clear manner. There are no comments in the code, but with proper naming conventions, reading the code is very easy and straightforward.
## Testing
To ensure reliability, tests have been provided. You can run them using dotnet test. To do this, navigate to the test folder while in the project directory:
```shell
cd tests
```

## Example of Events for Testing

```json
{
  "orderType": "CardVerify",
  "sessionId": "500cf308-e666-4639-aa9f-f6376015d1b4",
  "card": "4433**1409",
  "eventDate": "2023-04-07 05:29:54.362216 +00:00",
  "websiteUrl": "https://adidas.com"
},
{
  "orderType": "SendOtp",
  "sessionId": "500cf308-e666-4639-aa9f-f6376015d1b4", 
  "card": "4433**1409", 
  "eventDate": "2023-04-06 22:52:34.930150 +00:00",
  "websiteUrl": "https://somon.tj"
}
```

## API Endpoints
### 1. Create Notification Event
Endpoint
`POST /NotificationEvent`

#### Description
Creates a new notification event based on the provided data.

#### Request
Method: POST
Content Type: application/json
```json
{
  "orderType": "Purchase",
  "sessionId": "29827525-06c9-4b1e-9d9b-7c4584e82f56",
  "card": "4433**1409",
  "eventDate": "2023-01-04 13:44:52.835626 +00:00",
  "websiteUrl": "https://amazon.com"
}
```
#### Response
- Status Code 200: Operation executed successfully.
- Status Code 400: Something went wrong, please try again later

### 2. Receiving Notifications
##### Endpoint
`GET /NotificationEvent`

##### Description
Retrieves the stream of notifications.

Request:
- Method: GET
Response:
- Stream of `NotificationEventDto` objects in JSON format.

### Usage
##### **Creating a Notification**
To create a notification, send a POST request to `/NotificationEvent` with the event details in the request body.

Example using cURL:

```shell
curl -X POST -H "Content-Type: application/json" -d '{
  "orderType": "Purchase",
  "sessionId": "29827525-06c9-4b1e-9d9b-7c4584e82f56",
  "card": "4433**1409",
  "eventDate": "2023-01-04 13:44:52.835626 +00:00",
  "websiteUrl": "https://amazon.com"
}' http://localhost:{port}/NotificationEvent
```

#### **Receiving Notifications**
To retrieve notifications, send a GET request to `/NotificationEvent`.
Example using cURL:
```shell
curl http://localhost:{port}/NotificationEvent
```

### Dependencies
- `INotificationEventService`: Service responsible for handling notifications.
- `NotificationWorker`: Background worker responsible for notifying clients.

### Note
- Make sure to replace `http://localhost:{port}/` with the actual base URL of your API.
- This API utilizes asynchronous programming for improved performance.
