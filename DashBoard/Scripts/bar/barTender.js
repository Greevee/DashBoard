function bar(options) {

    this.max = parseInt((options.max).replace(/\D/g, ''));
    this.width = options.width;
    this.height = options.height;
    this.barColor = '#bfd255';
    this.bgColor = '#444';

    var rootele={};

    this.appendToEle = function (elem) {

        rootele = $('<div class="d_outer_bar"><div class="d_inner_bar"><span class="d_innerbar_value"></span></div></div>');
        elem.append(rootele);

        elem.find('.d_outer_bar').attr('style', 'width:' + this.width + ';height:' + this.height + ';background-color:' + this.bgColor);
        elem.find('.d_inner_bar').attr('style', 'background-color:' + 'aqua' + ';height:40%;width:100%');
    }

    this.updateValue = function (progress) {
        var percent = progress.toFixed(0).valueOf();
        if (percent > 100) {
            percent = 100;
            //wtf, how can this happen...
        }
        rootele.find('.d_inner_bar').height(percent + "%")

    }
    this.showValue = function (value) {
        rootele.find('span').text(value)

    }



}

var percentColors = [
    { pct: 0.0, color: { r: 0xff, g: 0x00, b: 0 } },
    { pct: 0.5, color: { r: 0xff, g: 0xff, b: 0 } },
    { pct: 1.0, color: { r: 0x00, g: 0xff, b: 0 } }];

var getColorForPercentage = function (pct) {
    for (var i = 1; i < percentColors.length - 1; i++) {
        if (pct < percentColors[i].pct) {
            break;
        }
    }
    var lower = percentColors[i - 1];
    var upper = percentColors[i];
    var range = upper.pct - lower.pct;
    var rangePct = (pct - lower.pct) / range;
    var pctLower = 1 - rangePct;
    var pctUpper = rangePct;
    var color = {
        r: Math.floor(lower.color.r * pctLower + upper.color.r * pctUpper),
        g: Math.floor(lower.color.g * pctLower + upper.color.g * pctUpper),
        b: Math.floor(lower.color.b * pctLower + upper.color.b * pctUpper)
    };
    return 'rgb(' + [color.r, color.g, color.b].join(',') + ')';
    // or output as hex if preferred
}