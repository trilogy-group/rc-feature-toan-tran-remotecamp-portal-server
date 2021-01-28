$containerName = "RemoteU-SQL-Server"

if ($IsWindows) {
    $dbDataPath = Join-Path $Env:TEMP "MsSqlData"

    if (-not (Test-Path $dbDataPath)) {
        New-Item $dbDataPath -ItemType Directory
    }

    $container = docker ps -a -f name=$containerName -q
    if ($container) {
        docker stop $containerName
        docker rm $containerName
    }

    docker run `
        --name $containerName `
        --rm `
        -v "$($dbDataPath):/var/opt/mssql/data/" `
        -e 'ACCEPT_EULA=Y' `
        -e 'SA_PASSWORD=P@ssw0rd!' `
        -e 'MSSQL_PID=Express' `
        -p 1433:1433 `
        -d `
        mcr.microsoft.com/mssql/server:2017-latest-ubuntu
}

if ($IsMacOS) {
    # https://github.com/microsoft/mssql-docker/issues/12

    $container = docker ps -a -f name=mssql -q
    if (-not $container) {
        docker create -v /var/opt/mssql --name mssql mcr.microsoft.com/mssql/server:2017-latest-ubuntu /bin/true
    }

    $container = docker ps -a -f name=$containerName -q
    if ($container) {
        docker stop $containerName
        docker rm $containerName
    }

    docker run `
        --name $containerName `
        --rm `
        --volumes-from mssql `
        -e 'ACCEPT_EULA=Y' `
        -e 'SA_PASSWORD=P@ssw0rd!' `
        -e 'MSSQL_PID=Express' `
        -p 1433:1433 `
        -d `
        mcr.microsoft.com/mssql/server:2017-latest-ubuntu
}

if ($IsLinux) {
    throw "Linux is not supported yet"
}




