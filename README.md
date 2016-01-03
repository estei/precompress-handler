# precompress-handler

An IIS Handler that handles pre compressed static assets.

Newer compression algorythms like zopfli are more efficent at compressing than Gzip which is used by IIS built in Http Compression.
What makes them stand out for us as developers though is the fact that they are really slow.
This means that we would prefer the compression to happen at build time.

This handler takes care of fetching the compressed version from the file system if the client requests a Gzipped version.