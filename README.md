# Identityserver_secure_api
Authorize API by IdentityServer3
### Features:


management app create client and scope 
![alt tag](https://github.com/cuongtranba/Identityserver_secure_api/blob/master/Capture.JPG )
### endpoins:

#### Client APP:
  use postmant
#### API resource: 
  1. http://localhost:29691/api/employee/Get.Employee
  2. http://localhost:29691/api/employee/Create.Employee

#### Authorize endpoint: 
  1. http://localhost:44351/connect/token

### Getting started
  1. client app will request Authorize endpoint to get access token key by enter clientId and Client secret which created by management app
  2. client app use access token key which get in step 1 to authorize API resource.
