import os.path
from MUser import MUser
class MUserDL:
    userList =[]
    @staticmethod
    def addUserIntoList(user):
        MUserDL.userList.append(user)
    @staticmethod
    def SignIn(user):
        for storedUser in MUserDL.userList:
            if(storedUser.username == user.username and storedUser.userPassword == user.userPassword):
                return storedUser
        return None
    @staticmethod
    def parseData(line):
        line = line.split(",")
        return line[0],line[1],line[2]
    @staticmethod
    def readDataFromFile(path):
        if(os.path.exists(path)):
            fileVariable = open(path , 'r')
            records = fileVariable.read().split("\n")
            #print(records)
            fileVariable.close()
            for line in records:
                username , userPassword , userRole = MUserDL.parseData(line)
                print(userPassword)
                user = MUser(username, userPassword, userRole)
                MUserDL.addUserIntoList(user)
                return True
            else:
                return False
    @staticmethod
    def storeUserIntoFile(user , path):
        file = open(path , 'a')
        file.write("\n " + user.username + "," + user.userPassword + "," + user.userRole)
        file.close();        