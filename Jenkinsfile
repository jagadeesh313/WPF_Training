pipeline {
    agent any

    stages {
        stage('Git Hub connected') {
            steps {
                bat 'echo " this is a report" > report.txt'
                archiveArtifacts allowEmptyArchive: true, artifacts: 'report.txt', fingerprint: true, followSymlinks: false, onlyIfSuccessful: true
            }
        }
    }
}
