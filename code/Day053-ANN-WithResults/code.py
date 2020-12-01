import numpy as np
import pandas as pd

dataset = pd.read_csv('data/Churn_Modelling.csv')
X = dataset.iloc[:, 3:-1].values
y = dataset.iloc[:, -1].values

from sklearn.preprocessing import LabelEncoder, OneHotEncoder
label_encoder_X_geography = LabelEncoder()
X[:, 1] = label_encoder_X_geography.fit_transform(X[:, 1])

from sklearn.compose import ColumnTransformer
ct = ColumnTransformer([("Geography", OneHotEncoder(), [1])], remainder = 'passthrough')
X = ct.fit_transform(X)

X = X[:, 1:]

label_encoder_X_gender = LabelEncoder()
X[:, 3] = label_encoder_X_gender.fit_transform(X[:, 3])

from sklearn.model_selection import train_test_split
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=0)
 
from sklearn.preprocessing import StandardScaler
standard_scaler_X = StandardScaler()
X_train = standard_scaler_X.fit_transform(X_train)
X_test = standard_scaler_X.transform(X_test)

import keras
from keras.models import Sequential
from keras.layers import Dense

classifier = Sequential()

# no of nodes are seected as average(input_features+output_features)
classifier.add(Dense(output_dim = 6, init='uniform', activation='relu', input_dim = 11))
classifier.add(Dense(output_dim = 6, init='uniform', activation='relu'))

# output layer
classifier.add(Dense(output_dim = 1, init='uniform', activation='sigmoid'))

classifier.compile(optimizer='adam', loss='binary_crossentropy', metrics=['accuracy'])

classifier.fit(X_train, y_train, batch_size=10, epochs=100)

classifier.save('weights.h5')

y_pred = classifier.predict(X_test)
y_pred = (y_pred > 0.5)

from sklearn.metrics import confusion_matrix
cm = confusion_matrix(y_test, y_pred)