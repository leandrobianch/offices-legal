powershell Write-Host "Executando pré build"
powershell Write-Host "Startando infraestrutura"
docker compose -f ..\..\eng\docker\docker-compose.yaml up dbsqlserver -d
powershell Write-Host "Finalizando infraestrutura"