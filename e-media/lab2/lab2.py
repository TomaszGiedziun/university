import random


class SafeForKids:
	
	def __init__(self,array_file_name='array.txt',key_file_name='key.txt',verbose=False):

		"""
			self.array_file_name = array_file_name
			self.array_file_name = array_file_name
			verbose - display debugg messages
		"""
		self.array_file_name=array_file_name
		self.key_file_name=key_file_name
		self.verbose = verbose

	def d(self, message):#verbose true/false whether you want to see prints
		if self.verbose:
			print message

	def generateArray(self,array_start=0,array_size=10):
		self.array_size = array_size
		"""
			array_start - offset 
			self.array_size = array_size
		"""
		self.array = [[((i+x)%self.array_size)+array_start for x in range(self.array_size)] for i in range(self.array_size)]
		self.d(self.array)
		with open(self.array_file_name,'w') as f:
			f.write(','.join([str(x) for x in self.array[0]])) 

	def readArray(self):
		with open(self.array_file_name,'r') as f:
			a = [line.split(",") for line in f][0]
			self.array_size = len(a)
			self.d( '%d %s' %(self.array_size , a))
			self.array = []
			for i in range(self.array_size):
				self.array.append(list(a))
				a.append(a.pop(0)) 
			self.d(self.array)

	def generateKey(self,key_size=5):
		self.key_size = key_size
		"""
			self.key_size = key_size
		"""
		if self.array:
			with open (self.key_file_name,'w') as f:
				c = list(self.array[0])
				random.shuffle(c)
				self.d([chr(c[x]) for x in range(self.key_size)])
				f.write(''.join([chr(c[x]) for x in range(self.key_size)]))

	def readKey(self):
		with open(self.key_file_name,'r') as f:
			self.key =[[x for x in line if ord(x)!= 32] for line in f][0] # reading key w/out space
			self.d(self.key)
			"""
				TO DO:
				check for validity
			"""


	def encrypt(self):
		"""
			TO DO:
			encyption and decrypition using : 
			[self.array_size - .index(x)]% self.array_size
		"""
		print 'lol'




if __name__ == "__main__":
	sfk = SafeForKids(verbose=True)
	sfk.generateArray(50)
	# sfk.readArray()
	sfk.generateKey()
	sfk.readKey()


