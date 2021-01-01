import time
import multiprocessing

def my_function():
    print("starting function")
    time.sleep(1)
    print("terminating function")

# if we dont use the main function. python gives a runtime error on windows (damn microsoft windows xD)

if __name__ == '__main__':
    # ---- Syncronous code
    tic = time.time()

    for _ in range(5):
        my_function()

    toc = time.time()
    elapsed = round(toc-tic, 2)
    print(f"Syncronous code took {elapsed} second(s)")


    # ---- Asyncronous code
    tic = time.time()

    # starting all the processes simultaneously
    processes = []
    for _ in range(5):
        process = multiprocessing.Process(target=my_function)
        process.start()
        processes.append(process)

    # waiting for all the processes to end
    for process in processes:
        process.join()

    toc = time.time()
    elapsed = round(toc-tic, 2)
    print(f"Asyncronous code took {elapsed} second(s)")
