###############################################################################
## Configuration
###############################################################################

Param([string]$configuration="Release")

###############################################################################

./Run-Build $configuration
./Run-Coverage $configuration
./Run-Reporter

###############################################################################