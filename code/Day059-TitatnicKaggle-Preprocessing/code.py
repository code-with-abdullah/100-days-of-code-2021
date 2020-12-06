import numpy as np
import pandas as pd

train_dataset = pd.read_csv('data/train.csv')
test_dataset = pd.read_csv('data/test.csv')

X_train = train_dataset.iloc[:, [2,4,5,6,7,9,11]].values
y_train = train_dataset.iloc[:, 1].values

X_test = test_dataset.iloc[:, [1,3,4,5,6,8,10]].values

from sklearn.preprocessing import LabelEncoder, OneHotEncoder
label_encoder_sex = LabelEncoder()

# Converting sex from categorical to binary variable
X_train[:, 1] = label_encoder_sex.fit_transform(X_train[:, 1])
X_test[:, 1] = label_encoder_sex.transform(X_test[:, 1])

# Filling age with mean age
from sklearn.impute import SimpleImputer
imputer_age_train = SimpleImputer(strategy='mean')
X_train[:, [2]] = imputer_age_train.fit_transform(X_train[:, [2]])
X_test[:, [2]] = imputer_age_train.transform(X_test[:, [2]])

# filling missing values of emarked
most_frequent_embarked = max(dict(train_dataset.Embarked.value_counts()))
for x in range(891):
    if (X_train[x, -1] != 'S' and X_train[x, -1] != 'Q' and X_train[x, -1] != 'C'):
        X_train[x, -1] = most_frequent_embarked # filling with most frequent 

embarked_encoder = LabelEncoder()
X_train[:, -1] = embarked_encoder.fit_transform(X_train[:, -1])

