import pyperclip as pc

Link = input("Link : ")
Eps = int(input("Episodes : ")) + 1
Season = int(input("Season : "))

Season = "S0"+ str(Season) +"E01"
Season_new = Season.replace("E01", "E")

for i in range(1, Eps):
    
    if i < 10:
        pc.copy(Link.replace(Season, "{}".format(Season_new + "0" + str(i))))
        print(Link.replace(Season, "{}".format(Season_new + "0" + str(i))))
        input("")
    else:
        pc.copy(Link.replace(Season, "{}".format(Season_new + str(i))))
        print(Link.replace(Season, "{}".format(Season_new + str(i))))
        input("")

input("The End")