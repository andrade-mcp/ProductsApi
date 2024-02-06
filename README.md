# Products API Documentation

## Introduction
This documentation outlines the endpoints and functionalities of the Products API.

## API Endpoints

### 1. Health Check
- **Endpoint:** `GET /`
- **Description:** Anonymous, health check/OK endpoint.
- **Request Format:**
  ```
  curl -X 'GET' \
    'http://localhost:5108/' \
    -H 'accept: */*'
  ```

- **Response Format (200):**
    ```json
    {
      "entries": {
        "HealthCheckService": {
          "data": {},
          "description": "The service is up and running.",
          "duration": "00:00:00.0028834",
          "exception": null,
          "status": 2,
          "tags": []
        }
      },
      "status": 2,
      "totalDuration": "00:00:00.0144601"
    }

### 2\. Get Products
- **Endpoint:** `GET /api/products`
- **Description:** Returns a list of all products 
- **Request Format:**
  ```
  curl -X 'GET' \
    'http://localhost:5108/api/products' \
    -H 'accept: text/plain'
  ```

- **Response Format (200):**
    ```json
    {
      "id": 0,
      "name": "string",
      "description": "string",
      "colour": "string"
    }

### 3\. Get Prices for Symbols

-   Endpoint: `GET /api/products/{colour}`
-   Description: Get all products of a specific colour
-   Query Parameters:
    -   `colour` (string): name of colour which products are requested.

- **Request Format:**
  ```
  curl -X 'GET' \
  'http://localhost:5108/api/products/blue' \
  -H 'accept: text/plain'
  ```

- **Response Format (200):**
    ```json
    {
      "id": 0,
      "name": "string",
      "description": "string",
      "colour": "blue"
    }


> [!NOTE]
> Steps required to initiate the application.

Running the Application
-----------------------

1.  Install the required dependencies using:
    - `dotnet restore`
2.  Run the application using the command:
    - `dotnet run`
3.  The API will be accessible at `http://localhost:5108`

Note: This documentation assumes that the API is running locally on the default port.

> [!IMPORTANT]
> Enhancements and Considerations for Scalability:

### 1\. Scalability:

-   Use a queue system to process transactions asynchronously and avoid bottlenecks.
-   Distribute processing across multiple server instances (horizontal scaling).
-   Use scalable cloud services to handle traffic spikes.

### 2\. Cache:
-   Implement a caching system to temporarily store the data of the most requested products and reduce the load on the services.
-   Use distributed caching to support multiple instances.

### 3\. Load Balancing:
-   Implement a load balancer to distribute traffic among different API instances.
-   Use load balancing services provided by cloud platforms.

### 4\. Monitoring and Logging:
-   Incorporate monitoring tools to track system performance, identify bottlenecks, and make adjustments as needed.
-   Configure detailed logs to trace activities and errors.
-   Notify clients through SignalR (implementation not provided here)

### 5\. Security:
-   Robust authentication and authorization using Json Web Tokens (JWT) to ensure only authorized users can perform requests.
-   Use encryption to protect sensitive data.

### 6\. Database:
- PostgreSQL or MSSQL can be implemented for the Minimum Viable Product (MVP) due to its simplicity and ease of integration, providing a quick solution for the initial development phase. However, as the project evolves, transitioning to OpenSearch is recommended for enhanced scalability, search capabilities, and overall performance. OpenSearch's features align better with the long-term requirements, offering a robust solution for managing and querying large datasets efficiently. The switch to OpenSearch ensures the system can seamlessly handle the growth and demands of a more advanced and scalable application.

### Evaluation:
-   Benefits:
    -   Modular and scalable design.
    -   Efficient use of cache to reduce the load on the database.
    -   Implementation of security practices.

-   Drawbacks:
    -   Need to manage and maintain distributed systems.
    -   Additional complexity due to the use of scalable technologies.

### Final Remarks:
-   This MVP provides a solid foundation for future expansion.
-   The proposed design focuses on efficiency and scalability.
-   Further development may include unit testing, detailed documentation, and specific implementation considerations for the production environment.