from PIL import Image
# root = '5.jpg'
# pic  = Image.open(root)
# pic = pic.resize((1002,300))
# pic.save('5.png')

for i in range(5):
    root = str(i+1) + '.png'
    pic = Image.open(root)
    pic = pic.resize((1002,180))
    pic.save(str(i+1) + '.png')