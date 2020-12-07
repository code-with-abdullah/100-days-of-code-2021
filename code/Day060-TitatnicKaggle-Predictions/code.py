import numpy as np
import pandas as pd
from sklearn.decomposition import PCA
from sklearn.impute import SimpleImputer
from sklearn.compose import ColumnTransformer
from sklearn.preprocessing import LabelEncoder, OneHotEncoder

train_dataset = pd.read_csv('data/train.csv')
test_dataset = pd.read_csv('data/test.csv')

X_train = train_dataset.iloc[:, [2,4,5,6,7,9,11]].values
X_test = test_dataset.iloc[:, [1,3,4,5,6,8,10]].values

y_train = train_dataset.iloc[:, 1].values

# Converting sex from categorical to binary variable
label_encoder_sex = LabelEncoder()
X_train[:, 1] = label_encoder_sex.fit_transform(X_train[:, 1])
X_test[:, 1] = label_encoder_sex.transform(X_test[:, 1])

# Filling missing age values with mean age
imputer_age = SimpleImputer(strategy='mean')
X_train[:, [2]] = imputer_age.fit_transform(X_train[:, [2]])
X_test[:, [2]] = imputer_age.transform(X_test[:, [2]])

X_train[:, 2] = np.round(list(X_train[:, 2]), 2)
X_test[:, 2] = np.round(list(X_test[:, 2]), 2)

imputer_fare = SimpleImputer(strategy='mean')
X_train[:, [5]] = imputer_age.fit_transform(X_train[:, [5]])
X_test[:, [5]] = imputer_age.fit_transform(X_test[:, [5]])

# filling missing values of emarked
most_frequent_embarked = max(dict(train_dataset.Embarked.value_counts()))
for x in range(891):
    if (X_train[x, -1] != 'S' and X_train[x, -1] != 'Q' and X_train[x, -1] != 'C'):
        X_train[x, -1] = most_frequent_embarked

embarked_encoder = LabelEncoder()
X_train[:, -1] = embarked_encoder.fit_transform(X_train[:, -1])
X_test[:, -1] = embarked_encoder.transform(X_test[:, -1])

# one hot encoding pclass
ct_pclass = ColumnTransformer([('one_hot_encoder', OneHotEncoder(categories='auto'), [0])],remainder='passthrough')
X_train = ct_pclass.fit_transform(X_train)
X_test = ct_pclass.transform(X_test)
# skipping dummy variable trap
X_train = X_train[:, 1:]
X_test = X_test[:, 1:]

# one hot encoding embarked
ct_embarked = ColumnTransformer([('one_hot_encoder', OneHotEncoder(categories='auto'), [7])],remainder='passthrough')
X_train = ct_embarked.fit_transform(X_train)
X_test = ct_embarked.transform(X_test)
# skipping dummy variable trap
X_train = X_train[:, 1:]
X_test = X_test[:, 1:]

X_train[:, -1] = np.round(list(X_train[:, -1]), 2)
X_test[:, -1] = np.round(list(X_test[:, -1]), 2)

pca = PCA(n_components=2)
train = pca.fit_transform(X_train)
test = pca.transform(X_test)
explained_variance = pca.explained_variance_ratio_

from sklearn.naive_bayes import GaussianNB
bayes_classifier = GaussianNB()
bayes_classifier.fit(train, y_train)

bayes_predictions = bayes_classifier.predict(test)

from sklearn.svm import SVC
svc_classifier = SVC()
svc_classifier.fit(train, y_train)

svc_predictions = svc_classifier.predict(test)

sum(bayes_predictions == svc_predictions)