
from MUserDL import MUserDL
from MUserUI import MUserUI
import os
from time import sleep


path = "Data.txt"
MUserDL.readDataFromFile(path)
option = 0 
while(option != 3):
    os.system("cls")
    option = MUserUI.menu()
    if(option == 1):
        user = MUserUI.takeInputWithoutRole()
        user = MUserDL.SignIn(user)
        if(user != None):
            if(user.isAdmin()):
                print("This is Admin")
            else:
                print("This is Manager")
        sleep(3)
    elif(option ==2):
        user = MUserUI.TakeInputFromConsole()
        MUserDL.addUserIntoList(user)
        MUserDL.storeUserIntoFile(user , path)    

  