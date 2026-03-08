<script>
	let { trigger, id, onDelete } = $props();
</script>

<section>
	<!-- <h1>Triggers</h1>
    <input type="text">
    <button></button> -->
	<p>{trigger}</p>
	<button>Edit</button>
	<button onclick={() => onDelete(id)}>Delete</button>
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
		margin: 0.75rem;
	}

	p {
		font-size: 1.25rem;
		justify-self: center;
	}
</style>
