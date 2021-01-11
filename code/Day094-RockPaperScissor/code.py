# ROCK, PAPER, SCISSOR

import random

def PrintChoices():
    print("1. Rock")
    print("2. Paper")
    print("3. Scissor")
    print("")

def ReturnChoiceBasedOnNumber(number):
    if number == 1:
        return "Rock"
    elif number == 2:
        return "Paper"
    return "Scissor"

def GetUserChoice():
    choice = int(input("Enter your choice : "))
    while (choice < 1 or choice > 3):
        choice = int(input("Re-Enter your choice between 1 and 3 : "))

    return ReturnChoiceBasedOnNumber(choice)

def GenerateComputersChoice():
    RandomNumber = random.randrange(1, 4)
    return ReturnChoiceBasedOnNumber(RandomNumber)

Draw = 0
WonByHuman = 0
WonByComputer = 0

while(True):
    PrintChoices()
    UserChoice = GetUserChoice()
    ComputerChoice = GenerateComputersChoice()

    if (UserChoice == ComputerChoice):
        Draw = Draw + 1
    elif (ComputerChoice == "Rock" and UserChoice == "Paper"):
        WonByHuman = WonByHuman + 1
    elif (ComputerChoice == "Rock" and UserChoice == "Scissor"):
        WonByComputer = WonByComputer + 1
    elif (ComputerChoice == "Paper" and UserChoice == "Scissor"):
        WonByHuman = WonByHuman + 1
    elif (ComputerChoice == "Paper" and UserChoice == "Rock"):
        WonByComputer = WonByComputer + 1
    elif (ComputerChoice == "Scissor" and UserChoice == "Rock"):
        WonByHuman = WonByHuman + 1
    elif (ComputerChoice == "Scissor" and UserChoice == "Paper"):
        WonByComputer = WonByComputer + 1
    
    print("\nChoice by YOU : " + UserChoice)
    print("Choice by Computer : " + ComputerChoice)

    print("\n-- Scorecard --")
    print("Drawn : " + str(Draw))
    print("Won by you : " + str(WonByHuman))
    print("Won by computer : " + str(WonByComputer) + "\n")

    proceed = input("Do you want to continue (y/n) : ")


    print("")
    if (proceed == 'n'):
        break
    print("")