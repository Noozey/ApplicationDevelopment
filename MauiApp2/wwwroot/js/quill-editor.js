window.QuillFunctions = {
    initQuill: function (editorElement, dotNetReference) {
        var quill = new Quill(editorElement, {
            modules: {
                toolbar: [
                    [{ 'header': [1, 2, false] }],
                    ['bold', 'italic', 'underline'],
                    [{ 'list': 'ordered' }, { 'list': 'bullet' }],
                    ['link', 'clean']
                ]
            },
            theme: 'snow'
        });

        // Update Blazor when text changes
        quill.on('text-change', function () {
            dotNetReference.invokeMethodAsync('UpdateContentFromJS', quill.root.innerHTML);
        });
        
        return quill;
    },
    setQuillContent: function (editorElement, content) {
        const quill = Quill.find(editorElement);
        if (quill) {
            quill.root.innerHTML = content || '';
        }
    }
};