import os
import sys
import math
import time
import shutil
import requests
from tqdm import tqdm
from bs4 import BeautifulSoup
from selenium import webdriver
from selenium.webdriver.common.keys import Keys

print('')
queryInput = input('Enter a query to search : ')

noOfImages = float(input("Enter the number of images : "))

if noOfImages > 20:
    noOfIterations = math.floor(noOfImages/20)
else:
    noOfIterations = 1

webDriver = webdriver.Firefox(executable_path = r'WebDrivers/geckodriver.exe')

if len(queryInput.split()) > 1:
    # will return imran khan as imran+khan
    query = '+'.join(queryInput.split())
else:
    query = queryInput

googleImagesUrl = r"https://www.google.com/search?tbm=isch&q="
URL = googleImagesUrl + query +'&oq=' + query

webDriver.get(URL)

#body = webDriver.find_element_by_name('body');

# the line of code to scroll a page is taken from

for i in range(noOfIterations):
    webDriver.execute_script("window.scrollTo(0, document.body.scrollHeight);")
    try:
        # ! https://stackoverflow.com/questions/20986631/how-can-i-scroll-a-web-page-using-selenium-webdriver-in-python
        webDriver.find_element_by_xpath("/html/body/div[2]/c-wiz/div[3]/div[1]/div/div/div/div/div[5]/input").click()
    except:
        pass
    time.sleep(1)

Soup = BeautifulSoup(webDriver.page_source, 'html.parser')

webDriver.quit()

if not os.path.exists('images'):
    os.mkdir('images')

saveFilePath = os.path.join(os.getcwd(), 'images', queryInput)

if os.path.exists(saveFilePath):
    counter = len(os.listdir(saveFilePath)) + 1
else:
    counter = 1
    os.mkdir(saveFilePath)

results = Soup.find_all('img', class_="Q4LuWd")[1:]

if noOfImages > len(results):
    scraped = results
    print("Could only get {} images".format(len(scraped)))
else:
    scraped = results[int(noOfImages)]

progressBar = tqdm(total = len(scraped))

#garbageFile = open('garbage.txt', 'a+')

for anImage in scraped:
    saveImagePath = os.path.join(saveFilePath, queryInput+'_{}.jpg'.format(counter))
    try:
        with open(saveImagePath, 'wb') as imageToSave:
            response = requests.get(anImage['src'], stream=True)
            shutil.copyfileobj(response.raw, imageToSave)
    except:
        pass
        # try:
        #     garbageFile.write(anImage['src']+"\n")
        # except:
        #     continue
    counter = counter + 1
    progressBar.update(1)

#garbageFile.close()
for imagesSaved in range(len(range(os.listdir(saveImagePath)))):
    if os.path.getsize(os.path.join(saveFilePath, imagesSaved)):
        os.remove(os.path.join(saveFilePath, imagesSaved))