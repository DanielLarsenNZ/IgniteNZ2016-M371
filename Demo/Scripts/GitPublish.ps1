$ErrorActionPreference = 'Stop'

# https://www.braintreepayments.com/blog/our-git-workflow/

# add a second remote (GitHub)
$uri = "https://github.com:$env:GITHUBPAT@github.com/DanielLarsenNZ/IgniteNZ2016-M371.git" 
git remote add github $uri

# pull master, release and squash merge
git checkout master
git pull
git checkout release
git pull
git merge --squash master

# commit, tag and push to GitHub remote
git commit -m "$env:BUILD_BUILDNUMBER"
git tag $env:BUILD_BUILDNUMBER -m "$env:BUILD_BUILDNUMBER"
git push github HEAD:master

# push commit to origin and merge to master
git push origin release
git checkout master
git merge release
git push origin master
