import numpy as np
import pandas as pd

# delimiter is set to tab as the file is tsv
dataset = pd.read_csv('data/Restaurant_Reviews.tsv', delimiter='\t', quoting=3)

# preprocessing (cleaning) the textual data using regular expression
import re

import nltk
nltk.download('stopwords')

from nltk.corpus import stopwords

from nltk.stem.porter import PorterStemmer

# keeping all letters
review = re.sub('[^a-zA-Z]', ' ', dataset['Review'][0])
# converting all the letters to lowercase
review = review.lower()
# convert sentence to list of words
review = review.split()

porter_stemmer = PorterStemmer()

# removing stopwords
review = [porter_stemmer.stem(word) for word in review if not word in stopwords.words('english')]