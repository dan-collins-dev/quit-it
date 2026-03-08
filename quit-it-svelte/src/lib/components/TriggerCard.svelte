<script>
    let { trigger } = $props();
</script>

<section>
    <!-- <h1>Triggers</h1>
    <input type="text">
    <button></button> -->
    <h1>{trigger}</h1>
    
</section>

<style>
    section {
        display: grid;
        grid-template-columns: 1fr;
        color: black;
		background-color: #fff;
		border-radius: 5px;
		box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
		padding: 1rem;
		margin: .75rem;
    }

    h1 {
        justify-self: center;
    }
</style>