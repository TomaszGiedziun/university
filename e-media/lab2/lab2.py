import random


class SafeForKids:
	
	def __init__(self,array_file_name='array.txt',key_file_name='key.txt',verbose=False):

		"""
			self.array_file_name - file containing only fist line of array
			self.key_file_name - file containing key 
			verbose - display debugg messages
		"""
		self.array_file_name=array_file_name
		self.key_file_name=key_file_name
		self.verbose = verbose

	def d(self, message):#verbose true/false whether you want to see prints
		if self.verbose:
			print message

	def generateArray(self,array_start=0,array_size=26):
		self.array_size = array_size
		self.array_start = array_start
		"""
			array_start - offset number in ascii
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
				self.key = [chr(c[x]) for x in range(self.key_size)]
				self.d(self.key)
				f.write(''.join([chr(c[x]) for x in range(self.key_size)]))

	def readKey(self):
		with open(self.key_file_name,'r') as f:
			self.key =[[x for x in line if ord(x)!= 32] for line in f][0] # reading key w/out space
			self.key_size = len(self.key)
			self.d('read key: %s' % self.key)
			"""
				TO DO:
				check for validity key in array
			"""

	def encrypt(self,in_file_name='in.txt',out_file_name='out.txt',key=None):
		"""
			self.out_file_name - output of this function
			self.in_file_name - input for this function
		"""
		self.out_file_name=out_file_name
		self.in_file_name=in_file_name
		if not key:
			key = self.key

		with open(self.in_file_name,'r') as f:
			c = [[x for x in line]for line in f][0]
			self.d('read: %s ' % c)
		if self.key_size > 1 :
			z = [key[x%self.key_size] for x in range(len(c))]
			for x in range(len(c)):
				if ord(c[x]) == 32:
					z.insert(x,' ')
					z.pop()
			self.d('trans: %s' % z)
		if self.key_size == 1:
			z = [x for x in c if x!=' ']
			z.insert(0,self.key[0]) # insert key to trans list
			z.pop() # pop last char of tans list (since you inserted one)
			for x in range(len(c)):
				if ord(c[x]) == 32:
					z.insert(x,' ')
			self.d('trans: %s' % z)
		o = []
		for x in range(len(c)):
			if ord(c[x]) in self.array[0]:
				arg1 = self.array[0].index(ord(c[x]))
			if ord(z[x]) in self.array[0]:
				arg2 = self.array[0].index(ord(z[x]))
			if ord(c[x]) in self.array[0] and ord(z[x]) in self.array[0]:
				o.append(chr(self.array[arg1][arg2]))
			if not(ord(c[x]) in self.array[0]) or not (ord(z[x]) in self.array[0])  :
				o.append(c[x])
		self.d('result: %s' % o)
		with open(self.out_file_name,'w')as f:
			f.write(''.join(j for j in o))


	def decrypt(self,in_file_name='out.txt',out_file_name='decrypted_out.txt'):
		self.d('Decrypt:')
		if self.key_size > 1: # decrypt case w/ logner then 1 key size
			decrypt_key = [chr(((self.array_size - self.array[0].index(ord(x)))% self.array_size)+self.array_start) for x in self.key]
			self.d(decrypt_key)
			self.encrypt(in_file_name='out.txt',out_file_name='decrypted_out.txt',key=decrypt_key)
		if self.key_size == 1: # decrypt case for autokey
			with open(in_file_name,'r') as f:
				c = [[x for x in line]for line in f][0]
				self.d('read: %s' % c)
				z = self.key
				o = []
			for x in range(len(c)):
				if ord(c[x]) == 32:
					z.insert(x,c[x])
					o.insert(x,c[x])	
					continue
				if ord(c[x]) in self.array[0]:
					arg1 = self.array[0].index(ord(c[x]))
				if ord(z[x]) in self.array[0]:
					arg2 = self.array[0].index(ord(z[x]))
				if ord(c[x]) in self.array[0] and ord(z[x]) in self.array[0]:
					arg = (self.array_size - self.array[0].index(ord(z[x])))%self.array_size
					z.append(chr(self.array[arg1][arg]))
					o.append(chr(self.array[arg1][arg]))
				if not(ord(c[x]) in self.array[0]) or not (ord(z[x]) in self.array[0]):
					o.append(c[x])
					z.append(c[x])
			self.d('result: %s' % o)



if __name__ == "__main__":
	sfk = SafeForKids(verbose=True)
	sfk.generateArray(array_start=97,array_size=26)
	# sfk.readArray()
	sfk.generateKey(key_size = 1)
	# sfk.readKey()
	sfk.encrypt()
	sfk.decrypt()


