var Spinner = function () {

    this.timer = null;
    this.angle = 0;
    this.position = 0;
    this.use_transit = false;

    this.at = 0;
    this.min = 6;
    this.start = null;
    this.to = null;
    this.callback = null;
    this.glitz_at = null;
    this.glitz_timer = null;
    this.glitz_start_timer = null;

}

var spinner = null;
var mmap = {
    1: 0,
    2: 5,
    3: 4,
    4: 3,
    5: 2,
    6: 1
};

Spinner.prototype.rotate_by_angle = function (angle) {
    $('#spinner').transition(
        { rotate: '+=' + angle },
        1000 * angle / 720,
        'linear');

    $('#mobile-spinner').transition(
        { rotate: '+=' + angle },
        1000 * angle / 720,
        'linear');

};

Spinner.prototype.m_start_rotating = function () {
    alert('call m_start_rotating');
    spinner.rotate_by_angle(spinner.angle);
    if (spinner.angle !== 720) {

        clearInterval(spinner.timer);
        spinner.timer = null;

        if (spinner.callback) {
            setTimeout(spinner.callback, 1000);
        }
    }
}

Spinner.prototype.m_spin = function () {
    alert('call m_spin');
    this.angle = 720;
    spinner = this;
    spinner.m_start_rotating();
    this.timer = setInterval(function () {
        spinner.m_start_rotating();
    }, 1000);
}


Spinner.prototype.m_stop = function () {
    clearInterval(this.timer);
    this.timer = null;
}

Spinner.prototype.m_spin_to = function (x, callback) {
    x = x + 1;
    this.angle = (mmap[x] - this.position + 6) * 60;
    this.position = mmap[x];
    this.callback = callback;

    manual_spin = (this.timer === null);

    if (manual_spin) {
        this.rotate_by_angle(this.angle);
    }
}

Spinner.prototype.spin = function () {
    alert('call spin');
    /* if we're already spinning, don't do anything */
    if (this.timer !== null) return;

    /* start clean */
    clearInterval(this.timer);
    this.timer = null;
    this.callback = null;

    if (this.use_transit) {
        this.m_spin();

    } else {
        this.at = this.at % 6;
        this.start = this.at;
        this.to = null;
        var me = this;
        this.timer = setInterval(function () { me.nextframe(); }, 30);
    }
}


Spinner.prototype.spinto = function (to, callback) {
    if (this.use_transit) {
        this.m_spin_to(to, callback);
    } else {
        this.spin();
        if (callback) this.callback = callback;
        this.to = to;
    }
}


Spinner.prototype.stop = function (at, internal) {
    /* stop spinning immediately */
    if (this.use_transit) {
        if (typeof at === 'undefined') {
            this.m_stop();
        } else {
            this.m_spin_to(at);
        }

    } else {

        clearInterval(this.timer);
        this.timer = null;

        if (typeof (at) === 'undefined') {
            /*  refactor */

        } else {
            this.at = at;
            this.rotate_to(-at);

            if (this.callback) {
                this.callback();
                this.callback = null;
            }
        }
    }
}


Spinner.prototype.nextframe = function () {
    this.at += .3;
    this.rotate_to(this.at);
    /* Is it time to terminate? */
    if (this.to !== null && (this.at - this.start) >= this.min && (this.at + this.to) % 6 < .5) {
        this.stop(this.to, true);
    }
}


Spinner.prototype.rotate_to = function (x) {
    var rot = (x % 6) * 60;
    $('#spinner').rotate(rot);
}
