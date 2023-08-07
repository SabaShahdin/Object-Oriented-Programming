class MUser:
    username = ""
    userPassword = ""
    userRole = ""

    def __init__ (self ,username, userPassword, userRole):
        self.username = username
        self.userPassword = userPassword
        self.userRole = userRole
        
    def isAdmin(self):
        if(self.userRole == "Admin"):
            return True
        else:
            return False