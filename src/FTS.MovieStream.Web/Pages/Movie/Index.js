$(function () {
    var l = abp.localization.getResource('MovieStream');

    var _movieAppService = fTS.movieStream.movies.movie;


    var data = _movieAppService.getMovies({});

    var dataTable = $('#MoviesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(_movieAppService.getMovies),
            columnDefs: [
                {
                    title: l('Film Adı'),
                    data: "title"
                },
                {
                    title: l('Film Türü'),
                    data: "title"
                }             
            ]
        })
    );
});

