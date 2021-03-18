
(function () {
    alert("lijian");
})();


///html/body/div[1]/div[3]/div[1]/div[3]/div[3]/div[1]/h3/a
(function () {
    var aTags = document.getElementsByTagName('a');
    var allClassName = '';
    for (var key in aTags) {
        var a = aTags[key];
        if (a['target'] !== '_blank') continue;
        allClassName += 'classList：' + a['href'] + '\r\n';
        if (a.attributes && a.attributes['data-landurl']) {
            var dataLandUrl = a.attributes['data-landurl'].value;
            allClassName += 'data-landurl：' + dataLandUrl + '\r\n';
            if (dataLandUrl === 'http://www.ztkjgz.com/') {
                a.click();
                break;
            }
        }
    }
    return allClassName;
})()