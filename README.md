# `LangVersion`: `latest`

BDN fails to generate benchmarks if `LangVersion` is non-numeric, for example `latest`.

> error MSB4086: A numeric comparison was attempted on "$(LangVersion)" that evaluates to "latest" instead of a number, in condition "'$(LangVersion)' == '' Or '$(LangVersion)' < '7.3'".
