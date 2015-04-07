1,bin folder should create below folders:
Download
Upload
Upload/After
Upload/Before
Upload/Source

2, config file like example

3. copy all the files include subdirs to Upload/Source folder.

4, the programe will do this things.

a, copy prd file to Upload/before folder and backup folder(if prd file exists).
b, copy local file to prd file(overwrite)
c, copy prd file to Upload/After folder
d, zip the log folder and Upload/Before and Upload/After folder and send via email.
e. zip the download file and send via email