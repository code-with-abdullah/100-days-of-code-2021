import keras
from keras.models import Sequential
from keras.layers import Convolution2D, Dense, MaxPooling2D, Flatten

model = Sequential()

model.add(Convolution2D(filters=32, kernel_size=3, padding="same", activation="relu"))
model.add(MaxPooling2D(pool_size=2, strides=2, padding='valid'))
model.add(Flatten())
model.add(Dense(units=128, activation='relu'))
model.add(Dense(units=1, activation='sigmoid'))

print(model.summary())

model.compile(optimizer='adam', loss='binary_crossentropy', metrics=['accuracy'])

model.fit_generator('dataset/train', epochs=25, validation_data='dataset/test', steps_per_epoch=2000)