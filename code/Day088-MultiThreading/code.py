import time
from threading import Thread

# ----- Synchronous code running sequentially

class c1():
    def run(self):
        time.sleep(1)
        print("c1")

class c2():
    def run(self):
        time.sleep(1)
        print("c2")

tic = time.time()

obj_c1 = c1()
obj_c2 = c2()

obj_c1.run()
obj_c2.run()

toc = time.time()

elapsed = toc-tic

print(f"Total time to run sync code {round(elapsed,2)}")


# ----- Asynchronous code running in parallel


class c1_threading(Thread):
    def run(self):
        time.sleep(1)
        print("c1-thread")

class c2_threading(Thread):
    def run(self):
        time.sleep(1)
        print("c2-thread")

tic = time.time()

obj_thread_c1 = c1_threading()
obj_thread_c2 = c2_threading()

obj_thread_c1.start()
obj_thread_c2.start()

obj_thread_c1.join()
obj_thread_c2.join()

toc = time.time()

elapsed = toc-tic

print(f"Total time to run a-sync code {round(elapsed,2)}")