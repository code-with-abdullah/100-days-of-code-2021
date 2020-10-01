import os
import shutil
import requests
from tqdm import tqdm
from bs4 import BeautifulSoup

# google images url from browser
googleImagesUrl = "https://www.google.com/search?tbm=isch&q="

# query instance to search for
print('')
queryInput = input('Enter a query to search : ')

if len(queryInput.split()) > 1:
    # will return imran khan as imran+khan
    query = '+'.join(queryInput.split())
else:
    query=queryInput

URL = googleImagesUrl+query+"&oq="+query

response = requests.get(URL)

soup = BeautifulSoup(response.text, "html.parser")

saveFilePath = os.path.join(os.getcwd(), 'images', queryInput)

if os.path.exists(saveFilePath):
    counter = len(os.listdir(saveFilePath)) + 1
else:
    counter = 0
    os.mkdir(saveFilePath)

results = soup.find_all('img')[1:]
pbar = tqdm(total = len(results))

for anImage in results:
    saveImagePath = os.path.join(saveFilePath, queryInput+'_{}.jpg'.format(counter))
    try:
        with open(saveImagePath, 'wb') as imageToSave:
            response = requests.get(anImage['src'], stream=True)
            shutil.copyfileobj(response.raw, imageToSave)
        counter = counter + 1
    except:
        print("error in image :", anImage['src'])
    pbar.update()