window.missilPolice = {
    goBack: function (fallbackUrl) {
        if (window.history.length > 1) {
            window.history.back();
            return;
        }

        if (fallbackUrl) {
            window.location.href = fallbackUrl;
        }
    }
};
