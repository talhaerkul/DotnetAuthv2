# Docker Setup Script for DotnetAuthv2
Write-Host "Setting up DotnetAuthv2 with Docker..." -ForegroundColor Green

# Stop and remove existing containers
Write-Host "Stopping existing containers..." -ForegroundColor Yellow
docker-compose down

# Build and start containers
Write-Host "Building and starting containers..." -ForegroundColor Yellow
docker-compose up -d --build

# Wait for SQL Server to be ready
Write-Host "Waiting for SQL Server to start..." -ForegroundColor Yellow
Start-Sleep -Seconds 30

# Run database migrations
Write-Host "Running database migrations..." -ForegroundColor Yellow
docker-compose exec dotnetauthv2 dotnet ef database update

Write-Host "Setup complete! Application is running on http://localhost:8080" -ForegroundColor Green
Write-Host "Swagger UI: http://localhost:8080/swagger" -ForegroundColor Cyan 