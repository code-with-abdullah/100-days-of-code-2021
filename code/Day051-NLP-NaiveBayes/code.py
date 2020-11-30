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

corpus = []

for index in range(dataset.shape[0]):
    # keeping all letters
    review = re.sub('[^a-zA-Z]', ' ', dataset['Review'][index])
    # converting all the letters to lowercase
    review = review.lower()
    # convert sentence to list of words
    review = review.split()
    
    porter_stemmer = PorterStemmer()
    
    # removing stopwords
    review = [porter_stemmer.stem(word) for word in review if not word in stopwords.words('english')]
    
    # converting list of words to sentence
    review = ' '.join(review)
    
    corpus.append(review)

# Creating the bag of words
from sklearn.feature_extraction.text import CountVectorizer
count_vectorizer = CountVectorizer(max_features = 1500)
X = count_vectorizer.fit_transform(corpus).toarray()
y = dataset.iloc[:, 1].values


from sklearn.model_selection import train_test_split
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=0)

from sklearn.naive_bayes import GaussianNB
classifier = GaussianNB()
classifier.fit(X_train, y_train)

y_pred = classifier.predict(X_test)

from sklearn.metrics import confusion_matrix
cm = confusion_matrix(y_test, y_pred)