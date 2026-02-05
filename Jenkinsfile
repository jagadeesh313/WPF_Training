pipeline {
    agent any

    stages {
        stage('Git Hub connection test') {
            steps {
                bat 'echo " this is a report" > report.txt'
                archiveArtifacts allowEmptyArchive: true, artifacts: 'report.txt', fingerprint: true, followSymlinks: false, onlyIfSuccessful: true
            }
        }
    }
}
