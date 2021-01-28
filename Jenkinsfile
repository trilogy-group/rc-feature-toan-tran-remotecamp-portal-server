String PUBLISH_MODE
String STAGE
String HOST_HEALTH_CHECK_PORT
String ENVIRONMENT
String GIT_HASH
String DEPLOY_DATE
String OLD_DEPLOYMENTS

encoded_branch_name = "${BRANCH_NAME}"
encoded_branch_name = encoded_branch_name.toLowerCase().replace("/", "-")
echo "Lower case branch: ${encoded_branch_name}"

pipeline {

  environment {
    PROJECT_ID = "remoteu-portal"
    ARTIFACT_ID = "remoteu-backend"
    HOST_PORT = 80
    CONTAINER_PORT = 80
    HEALTH_CHECK_ENDPOINT = "/api/ping"
    DTR_URL = "registry2.swarm.devfactory.com"
    SMTP_USERNAME = "remotecampautomation@trilogy.com"
    SMTP_PASSWORD = credentials("SMTP_PASSWORD")
    TEST_TLS_VERIFY = " "
    TEST_DOCKER_LINUX_HOST = "dl6.aureacentral.com"    
    PROD_TLS_VERIFY = "--tlsverify"            
    PROD_DOCKER_LINUX_HOST = "dl1.aureacentral.com"
    PROD_DOCKER_LINUX_PORT = "9998"
    TEST_DOCKER_LINUX_PORT = "2375"
    COMPANY = "teamrooms"
    TEAM = "remotecamp"
    EMAIL = "alex.netrebskiy@aurea.com"
    SKYPE = "aleks_lite"
    PRODUCT = "remotecamp"
    SERVICE = "remoteu-backend"
    ENDPOINT = "remoteu-backend.internal-webproxy.aureacentral.com"
    TEST_XO_JIRA_USERNAME = "testrcmng01@aurea.com"
    TEST_XO_JIRA_PASSWORD = credentials("XO_TEST_JIRA_PASSWORD")
    TEST_GOOGLE_API_EMAIL = "testmng01@testrem.iam.gserviceaccount.com"
    TEST_GOOGLE_API_PRIVATE_KEY = credentials("GOOGLE_API_PRIVATE_KEY_TEST_ACCOUNT")
    PROD_XO_JIRA_USERNAME = "remotecamp-qe@trilogy.com"
    PROD_XO_JIRA_PASSWORD = credentials("XO_JIRA_PASSWORD")
    PROD_GOOGLE_API_EMAIL = "remotecamp@remotecamp.iam.gserviceaccount.com"
    PROD_GOOGLE_API_PRIVATE_KEY = credentials("GOOGLE_API_PRIVATE_KEY")
    GITHUB_API_KEY = credentials("GITHUB_API_KEY")
    CROSSOVER_USER_NAME = "ugurdenizyavas@gmail.com"
    CROSSOVER_USER_PASSWORD = credentials("CROSSOVER_USER_PASSWORD")
    TEST_REMOTEU_DB_CONNECTION_STRING = credentials("REMOTEU_DB_DEV_CONNECTION_STRING")
    PROD_REMOTEU_DB_CONNECTION_STRING = credentials("REMOTEU_DB_PROD_CONNECTION_STRING")
    PROD_REMOTEU_NOSQL_DB_CONNECTION_STRING = credentials("REMOTEU_NOSQL_DB_PROD_CONNECTION_STRING")
    PROD_REMOTEU_NOSQL_DATABASE_NAME = "RemoteCampU"
    REMOTEU_PORTAL_AWS_ACCESS_KEY_ID = "AKIAQ2GY576NOZU3EGOQ"
    REMOTEU_PORTAL_AWS_SECRET_ACCESS_KEY = credentials("REMOTEU_PORTAL_AWS_SECRET_ACCESS_KEY")

  }

  agent {
    node {
      label "incorrect-jenkins-label"
    }
  }

  options {
    disableConcurrentBuilds()
    timestamps()
    timeout(time: 120, unit: "MINUTES")
  }

  stages {

    stage ("1) Setup - check which branch") {
      stages {

        stage("1.1) Set 'develop' branch parameters") {
          when {
            branch 'develop'
          }
          steps {
            script {
              PUBLISH_MODE = "Debug"
              STAGE = "dev"
              HOST_HEALTH_CHECK_PORT = 9301
              ENVIRONMENT = "Development"
              REMOTEU_DB_CONNECTION_STRING = "${TEST_REMOTEU_DB_CONNECTION_STRING}"
              SMTP_USERNAME = "${SMTP_USERNAME}"
              SMTP_PASSWORD = "${SMTP_PASSWORD}"
              XO_JIRA_USERNAME = "${TEST_XO_JIRA_USERNAME}"
              XO_JIRA_PASSWORD = "${TEST_XO_JIRA_PASSWORD}"
              GOOGLE_API_EMAIL = "${TEST_GOOGLE_API_EMAIL}"
              GOOGLE_API_PRIVATE_KEY = "${TEST_GOOGLE_API_PRIVATE_KEY}"
              REMOTEU_NOSQL_DB_CONNECTION_STRING = "mongodb://gaurav:wrongpassword@18.209.213.101/RemoteCampU"
              REMOTEU_NOSQL_DATABASE_NAME = "RemoteCampU"
              DOCKER_LINUX_HOST = "${TEST_DOCKER_LINUX_HOST}"
              DOCKER_LINUX_PORT = "${TEST_DOCKER_LINUX_PORT}"
              TLS_VERIFY = "${TEST_TLS_VERIFY}"
              echo "PUBLISH_MODE: ${PUBLISH_MODE}"
              echo "STAGE: ${STAGE}"
              echo "HOST_HEALTH_CHECK_PORT: ${HOST_HEALTH_CHECK_PORT}"
              echo "ENVIRONMENT: ${ENVIRONMENT}"
              echo "DOCKER_LINUX_HOST: ${DOCKER_LINUX_HOST}"
            }
          }
        }

        stage("1.1) Set 'release' branch parameters") {
          when {
            branch 'release'
          }
          steps {
            script {
              PUBLISH_MODE = "Release" // TODO Verify which to use
              STAGE = "qa"
              HOST_HEALTH_CHECK_PORT = 9302
              ENVIRONMENT = "Development" // TODO Verify which to use
              REMOTEU_DB_CONNECTION_STRING = "${TEST_REMOTEU_DB_CONNECTION_STRING}"
              SMTP_USERNAME = "${SMTP_USERNAME}"
              SMTP_PASSWORD = "${SMTP_PASSWORD}"
              XO_JIRA_USERNAME = "${TEST_XO_JIRA_USERNAME}"
              XO_JIRA_PASSWORD = "${TEST_XO_JIRA_PASSWORD}"
              GOOGLE_API_EMAIL = "${TEST_GOOGLE_API_EMAIL}"
              GOOGLE_API_PRIVATE_KEY = "${TEST_GOOGLE_API_PRIVATE_KEY}"
              REMOTEU_NOSQL_DB_CONNECTION_STRING = "mongodb://gaurav:wrongpassword@18.209.213.101/RemoteCampU"
              REMOTEU_NOSQL_DATABASE_NAME = "RemoteCampU"
              DOCKER_LINUX_HOST = "${TEST_DOCKER_LINUX_HOST}"
              DOCKER_LINUX_PORT = "${TEST_DOCKER_LINUX_PORT}"
              TLS_VERIFY = "${TEST_TLS_VERIFY}"
              echo "PUBLISH_MODE: ${PUBLISH_MODE}"
              echo "STAGE: ${STAGE}"
              echo "HOST_HEALTH_CHECK_PORT: ${HOST_HEALTH_CHECK_PORT}"
              echo "ENVIRONMENT: ${ENVIRONMENT}"
              echo "DOCKER_LINUX_HOST: ${DOCKER_LINUX_HOST}"
            }
          }
        }

        stage("1.1) Set 'master' branch parameters") {
          when {
            branch 'master'
          }
          steps {
            script {
              PUBLISH_MODE = "Release"
              STAGE = "staging"
              HOST_HEALTH_CHECK_PORT = 9303
              ENVIRONMENT = "Production"
              REMOTEU_DB_CONNECTION_STRING = "${PROD_REMOTEU_DB_CONNECTION_STRING}"
              SMTP_USERNAME = "${SMTP_USERNAME}"
              SMTP_PASSWORD = "${SMTP_PASSWORD}"
              XO_JIRA_USERNAME = "${PROD_XO_JIRA_USERNAME}"
              XO_JIRA_PASSWORD = "${PROD_XO_JIRA_PASSWORD}"
              GOOGLE_API_EMAIL = "${PROD_GOOGLE_API_EMAIL}"
              GOOGLE_API_PRIVATE_KEY = "${PROD_GOOGLE_API_PRIVATE_KEY}"
              REMOTEU_NOSQL_DB_CONNECTION_STRING = "${PROD_REMOTEU_NOSQL_DB_CONNECTION_STRING}"
              REMOTEU_NOSQL_DATABASE_NAME = "${PROD_REMOTEU_NOSQL_DATABASE_NAME}"
              DOCKER_LINUX_HOST = "${PROD_DOCKER_LINUX_HOST}"
              DOCKER_LINUX_PORT = "${PROD_DOCKER_LINUX_PORT}"
              TLS_VERIFY = "${PROD_TLS_VERIFY}"
              echo "PUBLISH_MODE: ${PUBLISH_MODE}"
              echo "STAGE: ${STAGE}"
              echo "HOST_HEALTH_CHECK_PORT: ${HOST_HEALTH_CHECK_PORT}"
              echo "ENVIRONMENT: ${ENVIRONMENT}"
              echo "DOCKER_LINUX_HOST: ${DOCKER_LINUX_HOST}"
            }
          }
        }

        stage("1.1) Set 'other' branch parameters") {
          when {
            not {
              anyOf {
                branch 'develop'
                branch 'release'
                branch 'master'
              }
            }
          }
          steps {
            script {
              PUBLISH_MODE = "Debug"
              STAGE = "regression"
              HOST_HEALTH_CHECK_PORT = 9304
              REMOTEU_DB_CONNECTION_STRING = "${TEST_REMOTEU_DB_CONNECTION_STRING}"
              SMTP_USERNAME = "${SMTP_USERNAME}"
              SMTP_PASSWORD = "${SMTP_PASSWORD}"
              XO_JIRA_USERNAME = "${TEST_XO_JIRA_USERNAME}"
              XO_JIRA_PASSWORD = "${TEST_XO_JIRA_PASSWORD}"
              GOOGLE_API_EMAIL = "${TEST_GOOGLE_API_EMAIL}"
              GOOGLE_API_PRIVATE_KEY = "${TEST_GOOGLE_API_PRIVATE_KEY}"       
              DOCKER_LINUX_HOST = "${TEST_DOCKER_LINUX_HOST}"      
              DOCKER_LINUX_PORT = "${TEST_DOCKER_LINUX_PORT}"
              TLS_VERIFY = "${TEST_TLS_VERIFY}"
              echo "PUBLISH_MODE: ${PUBLISH_MODE}"
              echo "STAGE: ${STAGE}"
              echo "HOST_HEALTH_CHECK_PORT: ${HOST_HEALTH_CHECK_PORT}"
              echo "DOCKER_LINUX_HOST: ${DOCKER_LINUX_HOST}"
            }
          }
        }
      }
    }

    stage ("2) Generate 'GIT_HASH' value from the SCM checkout") {
      steps {
        echo "Generating the 'GIT_HASH' value from the SCM checkout"
        script {
          GIT_HASH = sh (script: """
            set -e
            git rev-parse --short HEAD
          """, returnStdout: true).trim()
        }
        echo "GIT_HASH: ${GIT_HASH}"
      }
    }
    stage ("3) Build Docker Image") {
        stages {
            stage ("3.1) Run Tests") {
              steps {
                echo "Testing the source code..."
                sh "docker build -f Dockerfile --target test -t ${ARTIFACT_ID}-${encoded_branch_name}:test ."      
        
              }
            }
            
            stage ("3.2) Build Final Image") {
              steps {
                echo "Building the Docker image..."
                sh "docker build -f Dockerfile --build-arg PUBLISH_MODE=${PUBLISH_MODE} -t ${ARTIFACT_ID}-${encoded_branch_name}:latest ."      
              }
            }
        }
    }

    stage ("4) Run container") {
      steps {
        echo "Killing any existing Docker container running on the build agent..."
        sh """
          set -e
          if [[ \$(docker ps -a | grep ${ARTIFACT_ID}-${encoded_branch_name}) ]]; then
            docker kill ${ARTIFACT_ID}-${encoded_branch_name} 2> /dev/null || true
            docker rm ${ARTIFACT_ID}-${encoded_branch_name} 2> /dev/null || true
          fi
        """

        echo "Starting the '${ARTIFACT_ID}' Docker container for '${BRANCH_NAME}' branch..."
        sh """
          set -e
          docker run -d --restart=always \
                     --name ${ARTIFACT_ID}-${encoded_branch_name} \
                     -p ${HOST_HEALTH_CHECK_PORT}:${CONTAINER_PORT} \
                     ${ARTIFACT_ID}-${encoded_branch_name}:latest \
                     "" "" "" "" "" "" "" "" "" "" "" "" "" "" "Local" "Local"
        """
      }
    }

    stage ("5) Health-check the container") {
      steps {
        echo "Running a health-check of the container..."
        sh """
          set -e
          for x in {1..30} ; do
            [[ \$(curl -s -X GET 127.0.0.1:${HOST_HEALTH_CHECK_PORT}${HEALTH_CHECK_ENDPOINT}) ]] && echo "Received response from '${ARTIFACT_ID}-${BRANCH_NAME}'" && break
            sleep 3
          done
          curl -I -X GET 127.0.0.1:${HOST_HEALTH_CHECK_PORT}${HEALTH_CHECK_ENDPOINT} --fail
        """
        echo "Ran a successful Docker container health-check on '${ARTIFACT_ID}-${encoded_branch_name}'"
      }
    }   

    stage ("Proceed when branch is 'develop', 'release', or 'master'") {
      when {
        anyOf {
          branch 'develop'
          branch 'release'
          branch 'master'
        }
      }

      stages {

        stage ("6) Tag Docker image") {
          steps {
            echo "Applying 'GIT_HASH' and 'latest' tags to the Docker image..."
            sh "docker tag ${ARTIFACT_ID}-${BRANCH_NAME}:latest ${DTR_URL}/${PROJECT_ID}/${ARTIFACT_ID}-${BRANCH_NAME}:${GIT_HASH}"
            sh "docker tag ${ARTIFACT_ID}-${BRANCH_NAME}:latest ${DTR_URL}/${PROJECT_ID}/${ARTIFACT_ID}-${BRANCH_NAME}:latest"
          }
        }

        stage ("7) Push Docker image to DTR") {
          stages {
            stage ("7.1) Push tagged Docker images to DTR") {
              steps {
                echo "Pushing the Docker image to the remote registry..."
                sh "docker push ${DTR_URL}/${PROJECT_ID}/${ARTIFACT_ID}-${BRANCH_NAME}:${GIT_HASH}"
                sh "docker push ${DTR_URL}/${PROJECT_ID}/${ARTIFACT_ID}-${BRANCH_NAME}:latest"
              }
            }
          }
        }

        stage ("8) Deploy to DL - Non-Prod") {
          stages {
            stage ("8.1) Find old deployments on DL") {
              steps {
                echo "Finding old deployments on DL..."
                script {
                  OLD_DEPLOYMENTS = sh (script: """
                    set -e
                    docker ${TLS_VERIFY} -H ${DOCKER_LINUX_HOST}:${DOCKER_LINUX_PORT} ps -q -f "label=SERVICE_NAME=${STAGE}_${PRODUCT}_${SERVICE}"
                  """, returnStdout: true).trim()
                }
                sh """#!/bin/bash
                  set -e
                  echo "Found the following old deployment(s):"
                  for hash in ${OLD_DEPLOYMENTS}
                  do
                    CONTAINER_NAME=\$(docker ${TLS_VERIFY} -H ${DOCKER_LINUX_HOST}:${DOCKER_LINUX_PORT} inspect -f="{{.Name}}" \$hash)
                    echo \\'\${CONTAINER_NAME:1}\\'
                  done
                """
              }
            }

            stage ("8.2) Generate 'DEPLOY_DATE' value from the current date/time") {
              steps {
                echo "Generating the 'DEPLOY_DATE' value from the current date/time"
                script {
                  DEPLOY_DATE = sh (script: """
                    set -e
                    date +'%Y-%m-%d_%H-%M-%S'
                  """, returnStdout: true).trim()
                }
                echo "DEPLOY_DATE: ${DEPLOY_DATE}"
              }
            }

            stage ("8.3) Apply DB migrations") {
              steps {
                echo "Applying DB migrations..."
                sh """
                    docker build -f Dockerfile --build-arg PUBLISH_MODE=${PUBLISH_MODE} --target dbmigration -t ${ARTIFACT_ID}-${encoded_branch_name}:dbmigration .
                    docker run ${ARTIFACT_ID}-${encoded_branch_name}:dbmigration dotnet RemoteCamp.Portal.Database.MigrationTool.dll "${REMOTEU_DB_CONNECTION_STRING}"
                """
              }
            }

            stage ("8.4) Deploy new container to DL") {
              steps {
                echo "Deploying new container to DL..."
                sh """
                  set -e
                  docker ${TLS_VERIFY} -H ${DOCKER_LINUX_HOST}:${DOCKER_LINUX_PORT} run -d --restart=always \
                  --name ${STAGE}_${PRODUCT}_${SERVICE}_${GIT_HASH}-${BUILD_NUMBER} \
                  -l "SERVICE_NAME=${STAGE}_${PRODUCT}_${SERVICE}" \
                  -l "SERVICE_TAGS=\
trilogy.expose-v2,\
trilogy.redirecthttp,\
trilogy.cert=internal_default,\
trilogy.https,\
trilogy.internal,\
trilogy.endpoint=${STAGE}-${ENDPOINT},\
trilogy.client_req_max_size=100M,\
deploy.date=${DEPLOY_DATE},\
git.hash=${GIT_HASH},\
jenkins.build=${BUILD_NUMBER},\
jenkins.job=${JOB_NAME}" \
                  -l "com.trilogy.company=${COMPANY}" \
                  -l "com.trilogy.team=${TEAM}" \
                  -l "com.trilogy.maintainer.email=${EMAIL}" \
                  -l "com.trilogy.maintainer.skype=${SKYPE}" \
                  -l "com.trilogy.stage=${STAGE}" \
                  -l "com.trilogy.product=${PRODUCT}" \
                  -l "com.trilogy.service=${SERVICE}" \
                  -m "2048m" \
                  --cpu-quota 100000 \
                  -p ${HOST_PORT} \
                  ${DTR_URL}/${PROJECT_ID}/${ARTIFACT_ID}-${BRANCH_NAME}:${GIT_HASH} \
                  "${XO_JIRA_USERNAME}" "${XO_JIRA_PASSWORD}" "${GOOGLE_API_EMAIL}" "${GOOGLE_API_PRIVATE_KEY}" "${GITHUB_API_KEY}" "${CROSSOVER_USER_NAME}" "${CROSSOVER_USER_PASSWORD}" "${SMTP_USERNAME}" "${SMTP_PASSWORD}" "${REMOTEU_DB_CONNECTION_STRING}" "${REMOTEU_NOSQL_DB_CONNECTION_STRING}" "${REMOTEU_NOSQL_DATABASE_NAME}" "${REMOTEU_PORTAL_AWS_ACCESS_KEY_ID}" "${REMOTEU_PORTAL_AWS_SECRET_ACCESS_KEY}" "${STAGE}" "${ENVIRONMENT}"
                """
                echo "Deployed container '${STAGE}_${PRODUCT}_${SERVICE}_${GIT_HASH}-${BUILD_NUMBER}'"
                echo "DL-hosted '${STAGE}' container available at http://${STAGE}-${ENDPOINT}"
              }
            }

            stage ("8.5) Clean up old deployments on DL") {
              steps {
                echo "Cleaning up old deployments on DL..."
                sh """#!/bin/bash
                  set -e
                  for hash in ${OLD_DEPLOYMENTS}
                  do
                    CONTAINER_NAME=\$(docker ${TLS_VERIFY} -H ${DOCKER_LINUX_HOST}:${DOCKER_LINUX_PORT} inspect -f="{{.Name}}" \$hash)
                    echo Killing container \\'\${CONTAINER_NAME:1}\\'
                    docker ${TLS_VERIFY} -H ${DOCKER_LINUX_HOST}:${DOCKER_LINUX_PORT} kill \$hash 2> /dev/null || true
                    echo Removing container \\'\${CONTAINER_NAME:1}\\'
                    docker ${TLS_VERIFY} -H ${DOCKER_LINUX_HOST}:${DOCKER_LINUX_PORT} rm \$hash 2> /dev/null || true
                    echo
                  done
                """
              }
            }
          }
        }

        stage('Deploy to prod?') {
          when {
            beforeInput true
            branch 'master'
          }
          input {
            message "Deploy to prod?"
            ok "Just do it"
          }
          stages {
            stage ("9) Deploy to DL - Prod") {
              stages {
                stage ("9.1) Find old 'prod' deployments on DL") {
                  steps {
                    echo "Finding old 'prod' deployments on DL..."
                    script {
                      OLD_DEPLOYMENTS = sh (script: """
                        set -e
                        docker ${TLS_VERIFY} -H ${DOCKER_LINUX_HOST}:${DOCKER_LINUX_PORT} ps -q -f "label=SERVICE_NAME=prod_${PRODUCT}_${SERVICE}"
                      """, returnStdout: true).trim()
                    }
                    sh """#!/bin/bash
                      set -e
                      echo "Found the following old 'prod' deployment(s):"
                      for hash in ${OLD_DEPLOYMENTS}
                      do
                        CONTAINER_NAME=\$(docker ${TLS_VERIFY} -H ${DOCKER_LINUX_HOST}:${DOCKER_LINUX_PORT} inspect -f="{{.Name}}" \$hash)
                        echo \\'\${CONTAINER_NAME:1}\\'
                      done
                    """
                  }
                }

                stage ("9.2) Generate 'DEPLOY_DATE' value from the current date/time") {
                  steps {
                    echo "Generating the 'DEPLOY_DATE' value from the current date/time"
                    script {
                      DEPLOY_DATE = sh (script: """
                        set -e
                        date +'%Y-%m-%d_%H-%M-%S'
                      """, returnStdout: true).trim()
                    }
                    echo "DEPLOY_DATE: ${DEPLOY_DATE}"
                  }
                }

                stage ("9.3) Deploy new 'prod' container to DL") {
                  steps {
                    echo "Deploying new 'prod' container to DL..."
                    sh """
                      set -e
                      docker ${TLS_VERIFY} -H ${DOCKER_LINUX_HOST}:${DOCKER_LINUX_PORT} run -d --restart=always \
                      --name prod_${PRODUCT}_${SERVICE}_${GIT_HASH}-${BUILD_NUMBER} \
                      -l "SERVICE_NAME=prod_${PRODUCT}_${SERVICE}" \
                      -l "SERVICE_TAGS=\
trilogy.expose-v2,\
trilogy.redirecthttp,\
trilogy.cert=internal_default,\
trilogy.https,\
trilogy.internal,\
trilogy.endpoint=${ENDPOINT},\
trilogy.client_req_max_size=100M,\
deploy.date=${DEPLOY_DATE},\
git.hash=${GIT_HASH},\
jenkins.build=${BUILD_NUMBER},\
jenkins.job=${JOB_NAME}" \
                      -l "com.trilogy.company=${COMPANY}" \
                      -l "com.trilogy.team=${TEAM}" \
                      -l "com.trilogy.maintainer.email=${EMAIL}" \
                      -l "com.trilogy.maintainer.skype=${SKYPE}" \
                      -l "com.trilogy.stage=prod" \
                      -l "com.trilogy.product=${PRODUCT}" \
                      -l "com.trilogy.service=${SERVICE}" \
                      -m "2048m" \
                      --cpu-quota 100000 \
                      -p ${HOST_PORT} \
                      ${DTR_URL}/${PROJECT_ID}/${ARTIFACT_ID}-${BRANCH_NAME}:${GIT_HASH} \
                      "${XO_JIRA_USERNAME}" "${XO_JIRA_PASSWORD}" "${GOOGLE_API_EMAIL}" "${GOOGLE_API_PRIVATE_KEY}" "${GITHUB_API_KEY}" "${CROSSOVER_USER_NAME}" "${CROSSOVER_USER_PASSWORD}" "${SMTP_USERNAME}" "${SMTP_PASSWORD}" "${REMOTEU_DB_CONNECTION_STRING}" "${REMOTEU_NOSQL_DB_CONNECTION_STRING}" "${REMOTEU_NOSQL_DATABASE_NAME}" "${REMOTEU_PORTAL_AWS_ACCESS_KEY_ID}" "${REMOTEU_PORTAL_AWS_SECRET_ACCESS_KEY}" "prod" "${ENVIRONMENT}"
                    """
                    echo "Deployed container 'prod_${PRODUCT}_${SERVICE}_${GIT_HASH}-${BUILD_NUMBER}'"
                    echo "DL-hosted 'prod' container available at http://${ENDPOINT}"
                  }
                }

                stage ("9.4) Clean up old 'prod' deployments on DL") {
                  steps {
                    echo "Cleaning up old 'prod' deployments on DL..."
                    sh """#!/bin/bash
                      set -e
                      for hash in ${OLD_DEPLOYMENTS}
                      do
                        CONTAINER_NAME=\$(docker ${TLS_VERIFY} -H ${DOCKER_LINUX_HOST}:${DOCKER_LINUX_PORT} inspect -f="{{.Name}}" \$hash)
                        echo Killing container \\'\${CONTAINER_NAME:1}\\'
                        docker ${TLS_VERIFY} -H ${DOCKER_LINUX_HOST}:${DOCKER_LINUX_PORT} kill \$hash 2> /dev/null || true
                        echo Removing container \\'\${CONTAINER_NAME:1}\\'
                        docker ${TLS_VERIFY} -H ${DOCKER_LINUX_HOST}:${DOCKER_LINUX_PORT} rm \$hash 2> /dev/null || true
                        echo
                      done
                    """
                  }
                }
              }
            }
          }
        }
      }
    }
  }

  post {
    always {
      echo "Performing cleanup..."
      sh """
        set -e
        if [[ \$(docker ps -a | grep ${ARTIFACT_ID}-${encoded_branch_name}) ]]; then
          docker kill ${ARTIFACT_ID}-${encoded_branch_name} 2> /dev/null || true
          docker rm ${ARTIFACT_ID}-${encoded_branch_name} 2> /dev/null || true
        fi
      """
    }
  }
}
