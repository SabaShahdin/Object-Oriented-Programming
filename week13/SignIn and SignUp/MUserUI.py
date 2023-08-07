from MUser import MUser
class MUserUI:
    @staticmethod
    def menu():
        print("1.Sign IN")
        print("2. Sign Up")
        print("3. Enter Option")
        option = int(input())
        return option
    @staticmethod
    def printList(usersList):
        for user in userList:
            print(user.username , user.userPassword , user.userRole)
    @staticmethod
    def TakeInputFromConsole():
        username = input("Enter username")
        userPassword = input("Enter UserPassword")
        userRole = input("Enter user role")
        user = MUser(username , userPassword , userRole)
        return user
    @staticmethod
    def takeInputWithoutRole():
        username = input("Enter username")
        userPassword = input("Enter UserPassword")
        user = MUser(username , userPassword ,None)
        return user