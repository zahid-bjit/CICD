pipeline {  
  agent any  
  environment {  
    dotnet = 'C:\\Program Files\\dotnet\\dotnet.exe'  
  }  
  stages { 
    stage('Restore'){
      steps{
          bat "dotnet restore CICD_DotNet.sln"
      }
    }
    stage('Clean'){
      steps{
          bat "dotnet clean CICD_DotNet.sln"
      }
    }
    stage('Build') {  
      steps {  
        bat "dotnet build CICD_DotNet.sln --configuration Release" 
      }  
    }  
    stage('Test') {  
      steps {  
        bat "dotnet test CICD.Test\\CICD.Test.csproj --logger:trx"  
      }  
    }
    stage("Release"){
      steps {
        bat "dotnet build  CICD_DotNet.sln /p:PublishProfile=\"WebApplication1\\Properties\\PublishProfiles\\JenkinsProfile.pubxml\" /p:Platform=\"Any CPU\" /p:DeployOnBuild=true /m"
      }
    }
    stage('Deploy') {
      steps {
        // Stop IIS
        bat 'net stop "w3svc"'
        bat "xcopy /s WebApplication1\\bin\\Release\\net5.0 C:\\inetpub\\wwwroot"
        // Start IIS again
        bat 'net start "w3svc"'
      }
    }
  }  
}
