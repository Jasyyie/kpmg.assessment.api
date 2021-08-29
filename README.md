# KPMG Assessment

The application displays the list for all Dog breeds and related subbreeds. The application is developed using React js with TypeScript.
The backend API is built in .NET Core 5.0

### How to Build and Run this API

The API application can be run using docker, following the step below:

- `cd kpmg.assessment.api`
- Build the docker image: `docker build -t kpmg-assessment-api .`
- Run the docker container: `docker run -d -p 5000:5000 -it kpmg-assessment-api .`
- The OpenApi documentation will now be avaliable on `http://localhost:5000/swagger/index.html`

### How to Run the React application

- `cd kpmg.assessment.client/dog-finder`
- `npm start`
- The react (frontend) applications is now avaliable on `http://localhost:3000`
- NOTE: The react application only points to the API runnig on port 5000. Therefore, it would be easier to test the application with running the backend on the docker container.

### Structure

The project is structure to enable extensibility and ease of development. The structure is as follows:

#### kpmg.assessment.api

- Api is following Mediator Pattern.
- DogController is accepting the request type and giving the resposne back using the request handler and services.

#### kpmg.assessment.test

- Testing using Nsubsitute.

#### kpmg.assessment.client

- Front end is in React using Typescript.

#### Source code

- Clone the project on [Jasmine Github repository](https://github.com/Jasyyie/kpmg.assessment.api) and pull the repository to view the source code locally.
