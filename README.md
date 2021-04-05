# VtexChallenge

This challenge tries to emulate a shopcart and it's functions. Such as:

- Create a cart
- Put and remove items
- Apply discounts and calculate prices.

## How to run

### This api is able to run on docker!

- Build the docker image, for example:  *docker build -t "vtexchallenge" .*
- Run with: *docker run -p 8000:80 vtexchallenge*  (this one here might be on any port you want)
- The link to the swagger using the example with the ports above will be on: http://localhost:8000/swagger/index.html

### The auth configuration:

This app blocks non authorized requests, so you might wanna try login first!
The default login is user: *admin* password: *admin* (unfortunately is mocked so it can only log that with that user)
Copy the bearer token resulted from login and set him on swagger using the authorize button, if using curl or postman you can also set the value on your header.

## What is missing:

Unfortunately I couldn't finish the unit tests. But there are a few things I would love to improve in that project such as:

- Improving the response and error handling from endpoints
- Refactoring some weird classes
- Removing the mocks and using a database
- Add some logging

