---
title: 'The issue with SVG-image'
---
Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
![GitHubIcon]
Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.

[GitHubIcon]: https://unpkg.com/simple-icons@v6/icons/github.svg

```yaml
css: ['${.}/styles.css']
from: commonmark_x
input-file: ${.}/input.md
metadata: { lang: en-US }
self-contained: true
to: html5
variables: { document-css: false }
```

```css
img {
  background-color: #ffcfcf;
  height: 1em;
  width: 1em;
}
```

```
pandoc -d defaults.yaml -o output.html
pandoc -d defaults.yaml -o output.pdf
```
