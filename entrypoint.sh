#!/bin/bash

dotnet RemoteCamp.Portal.Web.dll \
       --XoJiraUserName=$1 \
       --XoJiraPassword=$2 \
       --GoogleApiEmail=$3 \
       --GoogleApiPrivateKey="$4" \
       --GithubAccessToken=$5 \
       --CrossoverUserName=$6 \
       --CrossoverPassword=$7 \
       --SmtpUserName=$8 \
       --SmtpPassword=$9 \
       --RemoteUPortalDbConnectionString="${10}" \
       --TicketBackupNoSqlDbConnectionString="${11}" \
       --TicketBackupNoSqlDatabaseName="${12}" \
       --AwsAccessKey="${13}" \
       --AwsSecretKey="${14}" \
       --Stage="${15}" \
       --environment=${16}
